b<-c(100, 6625)
A<-array(c(1,50,1,75), c(2,2))
solve(A,b)
AA<-t(A)%*%A
Ab<-t(A)%*%b
solve(AA, Ab)

A<-array(c(1,2,3,4,2,7,6,9,3,6,3,8,4,9,8,2), c(4,4))
solve(A)
t(A)
sum(diag(A))
det(A)
-1*det(A[-2,-3])
