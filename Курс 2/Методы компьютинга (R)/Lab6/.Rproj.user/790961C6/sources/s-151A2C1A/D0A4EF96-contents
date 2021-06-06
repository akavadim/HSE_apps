#Task1

#1
install.packages("openxlsx")
library(openxlsx)
df<-read.xlsx("villa.xlsx")[1:6]
View(df)

#2
str(df)

#3
library(nortest)
lillie.test(df$Price)

#4
var.test(df$Price~df$Eco, alternative="two.sided")

#5
t.test(df$Price~df$Eco, var.equal=FALSE)

#Task2

#1
df<-read.csv2("psych_survey.csv")
View(df)

summary(df$height)
summary(df$subject)

df<-subset(df,!is.na(df$subject))

df1<-subset(df, df$subject==1)
df2<-subset(df, df$subject==2)
df3<-subset(df, df$subject==3)
df4<-subset(df, df$subject==4)
df5<-subset(df, df$subject==5)

shapiro.test(df1$height)
shapiro.test(df2$height)
shapiro.test(df3$height)
shapiro.test(df4$height)
shapiro.test(df5$height)

anova<-aov(df$height~df$subject)
summary.aov(anova)
