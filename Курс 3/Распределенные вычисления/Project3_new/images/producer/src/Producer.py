# Producer
print('Start A')

from time import sleep
from json import dumps
from kafka import KafkaProducer
import string
import random
print('Start B')
producer = KafkaProducer(bootstrap_servers=['broker:9092'],
                         api_version=(0, 10),
                         value_serializer=lambda x:
                         dumps(x).encode('utf-8'))

#sleep(40)
class Info:

    def __init__(self, deviceId, deviceNum, temperature, location, latitude, longitude, time):
        self.deviceId = deviceId
        self.deviceNum = deviceNum
        self.temperature = temperature
        self.location = location
        self.latitude = latitude
        self.longitude = longitude
        self.time = time

    def getId(self):
        return self.deviceId

    def getNum(self):
        return self.deviceNum

    def getTem(self):
        return self.temperature

    def getLoc(self):
        return self.location

    def getLat(self):
        return self.latitude

    def getLon(self):
        return self.longitude

    def getTime(self):
        return self.time

print('Start C')
info = Info(deviceId="deviceId",
            deviceNum='deviceNum',
            temperature='temperature',
            location='location',
            latitude='latitude',
            longitude='longitude',
            time='time')

print('Start for')

# global data
for i in range(500000):
    data = {
        "deviceId": i,
        'deviceNum': i,
        'temperature': random.uniform(-50, 50),
        'location': {
            'latitude': random.uniform(-90, 90),
            'longitude': random.uniform(-180, 180)
        },
        'time': random.randint(1620000000, 1650000000)
    }
    producer.send('INPUT_DATA', value=data)
    #producer.flush()
    # sleep(1)

producer.close()
