turnout <- c(100, 124, 121, 130, 150, 155, 144, 132, 189, 145, 125, 110, 118, 129, 127)
x<-which(turnout%%5==0)
x
x<-round(length(x)/length(turnout), 2)
x
