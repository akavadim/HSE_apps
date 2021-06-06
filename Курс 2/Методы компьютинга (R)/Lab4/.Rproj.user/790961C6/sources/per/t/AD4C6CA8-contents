#Task1

#1
install.packages("openxlsx")
library(openxlsx)
df<-read.xlsx("AppleStore.xlsx")
View(df)

#2
df2<-df[-c(1, 4)]
View(df2)

#3
str(df2)

#4
summary(df$price)
summary(df$user_rating)
summary(df$lang_num)
summary(df$size_bytes)

#5
subset(df, df$lang_num==max(df$lang_num))$name

#6
quantile(df$price)
quantile(df$user_rating)
quantile(df$lang_num)

#7
install.packages("moments")
library(moments)
kurtosis(df$size_bytes)
kurtosis(df$price)
kurtosis(df$rating_count_tot)
kurtosis(df$user_rating)
kurtosis(df$lang_num)

skewness(df$size_bytes)
skewness(df$price)
skewness(df$rating_count_tot)
skewness(df$user_rating)
skewness(df$lang_num)

sd(df$size_bytes)/mean(df$size_bytes)
sd(df$price)/mean(df$price)
sd(df$rating_count_tot)/mean(df$rating_count_tot)
sd(df$user_rating)/mean(df$user_rating)
sd(df$lang_num)/mean(df$lang_num)

#8
boxplot(df$size_bytes, main='Размер приложения', xlab='Размер приложения, байты')
boxplot(df$price, main='Цена', xlab='Цена, USD')
boxplot(df$rating_count_tot, main='Количество оценок', xlab='Количество оценок')
boxplot(df$user_rating, main='Пользовательский рейтинг', xlab='Рейтинг')
boxplot(df$lang_num, main='Количество языков', xlab='Количество языков')

#9
pie(table(df$currency))
pie(table(df$prime_genre))

#10
hist(df$size_bytes)
hist(df$price)
hist(df$rating_count_tot)
hist(df$user_rating)
hist(df$lang_num)

#11
df$prime_genre<-as.factor(df$prime_genre)
summary(df$prime_genre)

#12
df2<-subset(df2, df2$prime_genre=='Games')
summary(df2$price)
summary(df2$user_rating)
summary(df2$lang_num)
summary(df2$size_bytes)

#13
mean_game<-mean(df2$price)
sd_game<-sd(df2$price)
ks.test(df2$price, "pnorm", mean_game, sd_game)

df<-subset(df, df$prime_genre!='Games')
mean_other<-mean(df$price)
sd_other<-sd(df$price)
ks.test(df$price, "pnorm", mean_other, sd_other)

shapiro.test(df$price)
shapiro.test(df$prime_genre)


(df$size_bytes)
(df$price)
(df$rating_count_tot)
(df$user_rating)
(df$lang_num)
    