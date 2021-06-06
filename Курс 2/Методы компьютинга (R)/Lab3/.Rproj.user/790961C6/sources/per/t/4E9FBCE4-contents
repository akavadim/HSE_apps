#Task1

df<-read.csv("train.csv")

#1
str(df)

#2
sum(complete.cases(df))
df_na<- df[!complete.cases(df),]

install.packages(c("mice", "VIM"))
library(mice)
library(VIM)

#3-4
aggr(df)

#5
df<-na.omit(df)

#Task2

#1
df$female<-as.numeric(lapply(df$Sex, function(x)if(x=="male") 0 else 1))
View(df)

#2
df2<-subset(df, df$Age>25 & df$Age<45 & (df$Pclass==2 | df$Pclass==3))
View(df2)

#3
sum(df$female=="0")
sum(df$female)

#4
survived<-subset(df, df$Survived==1)
min(survived$Age)
max(survived$Age)
aClass<-subset(survived, survived$Pclass==1)
sum(aClass$Age)/nrow(aClass)
