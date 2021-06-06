#1
install.packages("openxlsx")
library(openxlsx)
df<-read.xlsx("villa.xlsx")[1:6] 
View(df)

#2
str(df)

#3
summary(df)
#max = 2 => это неддопустимо, значение должно принимать от 0 до 1
df$Eco<-replace(df$Eco, df$Eco>1, 1)
summary(df)

#4
boxplot(df$Price, main="Цена")
boxplot(df$Dist, main="Дистанция")
boxplot(df$house, main="Площадь дома")
boxplot(df$area, main = "Площадь участка")

#5
sd(df$Price)/mean(df$Price)
sd(df$Dist)/mean(df$Dist)
sd(df$house)/mean(df$house)
sd(df$area)/mean(df$area)

#6a
hist(df$Price)

#6b
library(moments)
skewness(df$Price)
kurtosis(df$Price)

#6c
qqnorm(df$Price)
qqline(df$Price)

#6d
install.packages("nortest")
library(ggplot2)
library(nortest)

ks.test(df$Price, "pnorm", mean(df$Price), sd(df$Price))
shapiro.test(df$Price)
lillie.test(df$Price)
cvm.test(df$Price)
sf.test(df$Price)
pearson.test(df$Price)
