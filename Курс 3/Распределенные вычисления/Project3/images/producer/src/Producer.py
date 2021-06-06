# Producer
print('Start A')

from time import sleep
from json import dumps
from kafka import KafkaProducer
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
for i in range(1000):
    data = {
        info.getId(): i,
        info.getNum(): i,
        info.getTem(): i / 100,
        info.getLoc(): {
            info.getLat(): i / 100,
            info.getLon(): i / 100
        },
        info.getTime(): i
    }
    producer.send('INPUT_DATA', value=data)
    #producer.flush()
    # sleep(1)

producer.close()
