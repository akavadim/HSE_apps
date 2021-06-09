FROM openjdk:8-jre

# install python3 and pip3
RUN apt-get update -y && \
apt-get install -y python3.7 python3-pip python3.7-dev && rm -rf /var/lib/apt/lists/*
RUN ln -s /usr/bin/python3 /usr/bin/python

# install zookeper and kafka

RUN python -m pip install zookeeper;\
    python -m pip install kafka-python;

COPY docker-entrypoint.sh /
ENTRYPOINT [ "/docker-entrypoint.sh" ]

