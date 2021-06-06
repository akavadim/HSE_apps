df<-read.csv2("villa2.csv")
View(df)

#task 2
summary(df)

boxplot(df[2:6])
out<-boxplot.stats(df$Price)$out
out<-which(df$Price %in% boxplot.stats(df$Price)$out)
df<-df[-out, ]
boxplot(df)
out<-boxplot.stats(df$area)$out
out<-which(df$area %in% boxplot.stats(df$area)$out)
df<-df[-out, ]
boxplot(df)
out<-boxplot.stats(df$house)$out
out<-which(df$house %in% boxplot.stats(df$house)$out)
df<-df[-out, ]
boxplot(df)
out<-boxplot.stats(df$house)$out
out<-which(df$house %in% boxplot.stats(df$house)$out)
df<-df[-out, ]
boxplot(df)

#task 3
library(memisc)

model1<-lm(Price~log(house)+area+log(Dist)+Eco,df)
model2<-lm(Price~house+area+Dist+Eco,df)
model3<-lm(Price~log(house)+log(area)+log(Dist)+Eco,df)
summary(model1)
summary(model2)
summary(model3)

AIC(model1)
AIC(model2)
AIC(model3)

BIC(model1)
BIC(model2)
BIC(model3)

#task 4
model<-model3
x<-model.matrix(~0+log(house)+log(Dist)+log(area)+Eco, data=df)
cor(x)

vif(model)
mean(vif(model))

library("lmtest")
bptest(model, studentize = TRUE, data = df)
bptest(model, studentize = FALSE, data = df)

outlierTest(model)
influencePlot(model)
plot(model, which = c(1:5))

mean(model$residuals)
shapiro.test(model$residuals)
