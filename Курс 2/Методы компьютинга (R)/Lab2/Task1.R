income<-35000
log_income<-log(income)
income_pre<-500000
log_income
if(income>income_pre){
  print("income>income_pre")
} else if(income==income_pre) {
  print("income=income_pre")
} else{
  print("income<income_pre")
}
