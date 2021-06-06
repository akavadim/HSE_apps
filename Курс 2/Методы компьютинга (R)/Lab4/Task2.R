#Task2

#1
df <- read.csv("https://raw.githubusercontent.com/allatambov/R-programming-3/master/seminars/sem8-09-02/demography.csv", encoding = "UTF-8")

#2
df[["young_share"]]  <-df$young_total/df$popul_total*100
df[["trud_share"]]  <-df$wa_total/df$popul_total*100
df[["old_share"]]  <-df$ret_total/df$popul_total*100
View(df)

#3
install.packages("ggplot2")
library(ggplot2)
ggplot(df, aes(x = trud_share))+
  geom_histogram(colour="black", fill="white") +
  labs(x="Процент трудоспособного населения, %")+
  geom_rug()+
  geom_vline(xintercept= median(df$trud_share), color="red")


#4
ggplot(data = df, aes(x = trud_share, group = region, fill=region)) +
  geom_density(alpha = 0.5)
ggplot(data = df, aes(x="", y = trud_share, group = region, fill=region)) +
  geom_violin()
       
#5
ggplot(df, aes(young_share, old_share))+
  geom_point(color="red", size=2)

#6
df[["male_share"]]<-(df$young_male+df$wa_male+df$ret_male)/df$popul_total
df[["male"]]<-factor(ifelse(df$male_share>0.5,1,0))
View(df)

#7
ggplot(df, aes(young_share,old_share ))+
  geom_point(aes(size=male_share, color=male))

#8
ggplot(df, aes(x=region))+geom_bar()
