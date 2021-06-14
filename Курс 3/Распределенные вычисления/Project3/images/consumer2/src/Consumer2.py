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

time = None
for (i, msg) in enumerate(consumer):

  if i == 0:
    time = datetime.now().timestamp()
  
  if i % 100000==0 and i!=0:
    time_spent =  datetime.now().timestamp() - time
    time = datetime.utcnow().timestamp()

    print("Время: {0} Индекс текущего элемента: {1}".format(time_spent, i))
    print(msgpack.unpackb(base64.decodebytes(msg.value["res"].encode('utf-8'))), i)

  if i == 500000:
    break

  i+= 1
  


consumer.close()

# print('End consumer')