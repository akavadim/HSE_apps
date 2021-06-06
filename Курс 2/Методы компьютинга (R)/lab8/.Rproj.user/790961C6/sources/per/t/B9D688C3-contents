#task 1
df<-read.csv("villa2.csv", sep=";")
View(df)
df$Price<-as.numeric(df$Price)
df$Dist<-as.numeric(df$Dist)
df$area<-as.numeric(df$area)
df$Eco<-as.factor(df$Eco)

#task 2
summary(df)
boxplot(df)

#task 3
install.packages("ggplot2")
library(ggplot2)
ggplot(df) +geom_point(aes(x=Price, y=Dist, color=Eco))
ggplot(df) +geom_point(aes(x=Price, y=house, color=Eco))
ggplot(df) +geom_point(aes(x=Price, y=area, color=Eco))
ggplot(df) +geom_point(aes(x=house, y=area, color=Eco))

#task 4
model<-lm(formula = Price~house+area, data=df)
model
summary(model)
AIC(model)
BIC(model)

#task 5
library(car)
mean(vif(model))

X <- model.matrix(~ 0 + house+area, data = df)
cor(X)

#task 5
model<-lm(formula = Price~log(house)+log(area)+Eco, data = df)
model2<-lm(formula = log(Price)~log(house)+area+log(Dist) + Eco, data=df)

summary(model)
summary(model2)

AIC(model)
AIC(model2)

BIC(model)
BIC(model2)
