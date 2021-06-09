# Consumer
print('Start consumer2')
from datetime import datetime
from kafka import KafkaConsumer
from time import sleep
import json 
import msgpack
from codecs import encode
import base64

# sleep(10)
consumer = KafkaConsumer(
     'Out',
     bootstrap_servers=['broker:9092'],
    #  auto_offset_reset='earliest',
#     # enable_auto_commit=True,
#     # group_id='INPUT_DATA',
      value_deserializer=lambda v:json.loads(v.decode('utf-8')),
#     # # value_deserializer=lambda x: x,
#     # consumer_timeout_ms=1000,
#     # api_version=(0, 10))
 )
    
# sleep(20)

i=0
time = datetime.utcnow()
for msg in consumer:
  i+= 1
  if i == 0:
    time = datetime.utcnow()
  
  if i == 100000: 
    print(time.timestamp() - datetime.utcnow().timestamp(), i)
    time = datetime.utcnow()
    print(msgpack.unpackb(base64.decodebytes(msg.value["res"].encode('utf-8'))), i)

  if i == 200000: 
    print(time.timestamp() - datetime.utcnow().timestamp(), i)
    time = datetime.utcnow()
    print(msgpack.unpackb(base64.decodebytes(msg.value["res"].encode('utf-8'))), i)

  if i == 299999: 
    print(time.timestamp() - datetime.utcnow().timestamp(), i)
    time = datetime.utcnow()
    print(msgpack.unpackb(base64.decodebytes(msg.value["res"].encode('utf-8'))), i)
 
  if i == 300000:
    break


consumer.close()

# print('End consumer')