# Consumer
print('Start consumer')
from kafka import KafkaConsumer
from time import sleep
import json 

# sleep(10)
consumer = KafkaConsumer(
     'INPUT_DATA',
     bootstrap_servers=['broker:9092'],
    #  auto_offset_reset='earliest',
#     # enable_auto_commit=True,
#     # group_id='INPUT_DATA',
#     # value_deserializer=lambda x: load(x.decode('utf-8')),
#     # # value_deserializer=lambda x: x,
#     # consumer_timeout_ms=1000,
#     # api_version=(0, 10))
 )
    
# sleep(20)

i=0
for msg in consumer:
  print('Start data: ', msg.value)
  # print('dod: ', type(msg))
  # print((msg.value).decode('utf8').replace("'", '"'))
    
  # record = json.loads((msg.value).decode('utf8'))
  # location = (record['location'])
  # deviceId = int(record['deviceId'])
  # deviceNum = int(record['deviceNum'])
  # temperature = float(record['temperature'])
  # latitude = float(location['latitude'])
  # longitude = float(location['longitude'])
  # time = float(record['time'])
  
  # i+=1
  # if i>100:
  #   break

consumer.close()

# print('End consumer')