from pyflink.table import DataTypes, Row, udf
from pyflink.datastream import StreamExecutionEnvironment
from pyflink.datastream.connectors import StreamingFileSink
import json
from pyflink.table.descriptors import CustomFormatDescriptor, FormatDescriptor, Schema, Kafka, Json
from pyflink.table import StreamTableEnvironment, EnvironmentSettings
import msgpack
import datetime

def register_producer(st_env):
    st_env \
        .connect(  # declare the external system to connect to
        Kafka()
            .version("universal")
            .topic("INPUT_DATA")
            .start_from_latest()
            .property("zookeeper.connect", "zookeeper:2181")
            .property("bootstrap.servers", "broker:9092")
            ) \
        .with_format(  # declare a format for this system
        Json()
            .fail_on_missing_field(True)
            .schema(DataTypes.ROW([
            DataTypes.FIELD("deviceId", DataTypes.INT()),
            DataTypes.FIELD("deviceNum", DataTypes.INT()),
            DataTypes.FIELD("temperature", DataTypes.FLOAT()),
            DataTypes.FIELD("location", DataTypes.ROW( [DataTypes.FIELD("latitude", DataTypes.FLOAT()), DataTypes.FIELD("longitude", DataTypes.FLOAT())])),
            DataTypes.FIELD("time", DataTypes.BIGINT())]))) \
        .with_schema(  # declare the schema of the table
        Schema()
            .field("deviceId", DataTypes.INT())
            .field("deviceNum", DataTypes.INT())
            .field("temperature", DataTypes.FLOAT())
            .field("location", DataTypes.ROW( [DataTypes.FIELD("latitude", DataTypes.FLOAT()), DataTypes.FIELD("longitude", DataTypes.FLOAT())]))
            .field("time", DataTypes.BIGINT())) \
        .in_append_mode() \
        .create_temporary_table("input")

def register_consumer(st_env):
    st_env.connect(  # declare the external system to connect to
        Kafka()
            .version("universal")
            .topic("Out")
            .start_from_earliest()
            .property("zookeeper.connect", "zookeeper:2181")
            .property("bootstrap.servers", "broker:9092")
            ) \
        .with_format(  # declare a format for this system
         Json()
             .fail_on_missing_field(True)
             .schema(DataTypes.ROW([DataTypes.FIELD("res", DataTypes.BYTES())]))
            ) \
        .with_schema(  # declare the schema of the table
        Schema()
            .field("res", DataTypes.BYTES())) \
        .in_append_mode() \
        .create_temporary_table("output")

def hello_world():
    env = StreamExecutionEnvironment.get_execution_environment()
    env.set_parallelism(1)

    st_env = StreamTableEnvironment.create(env, environment_settings=EnvironmentSettings
                .new_instance()
                .in_streaming_mode()
                .use_blink_planner()
                .build())

    register_producer(st_env)
    register_consumer(st_env)

    st_env.from_path("input")\
    .map(udf.udf(map_function, result_type= DataTypes.ROW( [DataTypes.FIELD( "res", DataTypes.BYTES())]))) \
    .insert_into("output")

    st_env.execute("tutorial_job2")

def map_function(s):
    def hash_device_id(data):
        return hash(data)
    def convert_to_farengheit(data):
        return (data*9/5)+32
    def get_location(location):
        if(location[0]<77.0 and location[0]>37 #Широта
            and location[1] < 189 and location[1]> 53):
            return "Russia"
        return "unknown"
    def get_msk_datetime(data):
        timestamp = datetime.datetime.fromtimestamp(data+(3600*3))
        return "{0}:{1}:{2} {3}:{4}:{5}".format(timestamp.year, timestamp.month, timestamp.day, timestamp.hour, timestamp.minute, timestamp.second)

    device_id = hash_device_id(s[0])
    temp = convert_to_farengheit(s[2])
    location = get_location(s[3])
    msk_datetime = get_msk_datetime(s[4])

    jsonObj = {
        "hasheddevicedid":device_id,
        "f_temp": temp,
        "location": location,
        "msk_datetime": msk_datetime
    }

    #res = json.dumps({"res": msgpack.packb(jsonObj)})

    return Row(msgpack.packb(jsonObj))
    #return Row(msgpack.packb(res))


if __name__ == '__main__':
    hello_world()