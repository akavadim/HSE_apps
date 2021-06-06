income <- c(10000, 32000, 28000, 150000, 65000, 1573)
middle <-sum(income)/length(income)
income_class <-replace(income,income<middle, 0)
income_class <-replace(income_class,income>=middle, 1)
income_class
