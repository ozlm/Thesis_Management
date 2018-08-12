gene <- "AKT1"
g_exp <- 5.7
g_mut <- TRUE
gene_vector <- c("AKT1", "TP53", "VEGFA", "DDR1", "MAPK3")
exp_vector <- c(3, -2, 4, 1, 5)
bool_vector <- c(TRUE, FALSE, TRUE, FALSE, TRUE)
rand_num <- seq(from = 3, to = 100, length = 30)
rand_num
rand_num <- seq(from = 3, to = 100, length = 30)
rand_num
gene_vector[3]
exp_vector>1
gene_vector[c(2,3)]
bool_vector c(TRUE)
bool_vector [c(TRUE)]
bool_vector==TRUE
sum(exp_vector)
pos_exp <- (exp_vector>0)
exp_vector[pos_exp]
gene_list <- list("AKT1", 207, "serine kinase 1")
names(gene_list)=c("gene", "id", "name" )
gene_list <- c(gene_list, chromosome=14.0)
x <- seq(from = 5, to = 10, length =15)
exp_matrix <- matrix(x, byrow = TRUE, nrow=5)
exp_matrix
rownames(exp_matrix) <- c("gene1", "gene2", "gene3", "gene4", "gene5")
colnames(exp_matrix) <- c("s1","s2","s3”)
cr <- rowSums(exp_matrix)
which.max(cr)
subB <- exp_matrix[4:5,2:3]
dim(mtcars)
smallc <- subset(mtcars, subset=cyl<=6)
head(smallc)
length(smallc)
nrow(smallc)
sum(smallc$hp)/nrow(smallc)
rownames(subset(smallc, subset=gear == 5))


max(company$salary,na.rm=TRUE)

inp_vec <- c(5, 2, 7, 6, 3, 19, 23, 78, 145, 3, 4, 6, 9, 12, 67)
for(i in inp_vec){
if(i%%2 == 0)
                          {
cat(i ,"is even", "\n")
                          }
else{
cat(i ,"is odd", "\n")

}
}

name <- c("Ali","Cenk","Mete")
age <- c(26,32,29)
salary <- c(2700, 3200, 4900)
company <- data.frame(name=name, age=age, salary=salary)
company[which.max(company$salary),]


dim(iris)
apply(iris[,1:4], 2, mean)

myList <- list (iris[1:10, 1:4 ])


sapply(myList, function(1:10) , sum(X), simplify = TRUE, USE.NAMES = TRUE)

result <- rep(myList, 100); for(i in 1:100) result[i] <- sum(1:i)
result2 <- sapply(myList, function(i) sum(1:i))

counts <- table(mtcars$gear)
barplot(counts, horiz=FALSE,  names.arg=c("3 ", "4 ", "5 "))

myList <- iris[1:10,1:4]
retList<- apply(myList, 2, sum)
retList["Petal.Length"]

vec <- c("Ali", "ayþe", "ahmet", "Ali", "ayþe", "Ali")
calculate <- function(vec)
 { 
   
  count<-0
  for(i in vec){
    if(i =="Ali") {
      count<-count+1
  }
  } 
  return(count)
  
}
calculate(vec)

myList <- iris[1:10,1:4]
retList<- apply(myList, 2, sum)
retList["Petal.Length"]
retVec<-apply(myList,2,mean)
retVec

inp <-c ('Ayþe','Ali','Veli')
match('Ali',inp)

b<-'NA'
myVec <-c ('Ayþe','Veli','NA','Ali','Veli')
match(b,myVec,nomatch = -1)
gene1 <- c(15,10,5)
> plot(gene1)
> 
> barplot(gene1, xlab="Gene Type",border="blue",
+         names.arg=c("3","4","5"),
+         density=c(20,25,30))


gene1 <- c(15,10,5)
plot(gene1)
barplot(gene1, xlab="Gene Type",border="blue", names.arg=c("3","4","5"),    density=c(10,25,30))


proteinData= read.table("C:/Users/özlem/Desktop/Protein.txt")
dim(proteinData)
colnames(proteinData)
myList <- iris[1:10,1:4]
myList

patientData<-read.csv("C:/Users/özlem/Desktop/Patient-Subtype.csv")
dim(patientData)

head(patientData)
colnames(patientData)

btype<-subset(patientData,subset=Sub,type==basal)
gene1 <- c(0.04,0.07,0.05,0.01,0.02)
 plot(gene1)


plot(gene1, type="o", pch=8,lty=1, col="green",ylim=c(0,08), xlab="Petrol Consumption",ylab="Density")

lines(gene2, type="o",pch=10, lty=2, col="red")

barplot(gene1, names.arg=c("10","15","20","25","30","35"),density=c(80,80,80,80,80))



hist(dat, col="lightblue", freq=FALSE, xlab="expression levels", ylim=c(0,0.3))

#add a density curve

lines(density(dat),col="blue")

btype<-subset(patientData,subset="Sub.type" == "basal")
basalPatientID <- btype("Patient.ID")

patientData<-read.csv("C:/Users/özlem/Desktop/Patient-Subtype.csv")
dim(patientData)
a <- subset(patientData, subset= "Sub.type" == basal)
a
dim(mtcars)
mtcars
mtdisp <- density(mtcars$disp)
mthp <- density(mtcars$hp)

plot(range(mtdisp$x, mthp$x), range(mtdisp$y, mthp$y), type = "n", xlab = "Distribution of engine horsepower and displacement values", ylab = "Density")
lines(mtdisp, col = "blue", lwd=4)
lines(mthp, col = "red", lwd=4) 

counts <- table(mtcars$gear)
barplot(counts, horiz=FALSE,  names.arg=c("3 ", "4 ", "5 "))

d2 <- mtcars$qsec
  d1 <- mtcars$hp
plot(d1,d2,pch=7,ylab = "Seconds to get 0,4 km", xlab ="Horsepower" )


gene1 <- c(0.04,0.07,0.05,0.01,0.02)
 plot(gene1)


plot(gene1, type="o", pch=8, lty=1, col="green", ylim=c(0,08), xlab="Petrol Consumption", ylab="Density")

lines(gene2, type="o", pch=10, lty=2, col="red")

barplot(gene1, names.arg=c("10","15","20","25","30","35"),density=c(80,80,80,80,80))


hist(dat, col="lightblue", freq=FALSE, xlab="expression levels", ylim=c(0,0.3))


patientData <- read.csv2(file="C:/Users/özlem/Desktop/Patient-Subtype.csv", header = TRUE, sep = ";", quote ="\"", dec = ",", fill = TRUE, comment.char = "")
dim(patientData)
head(patientData)
colnames(patientData)
basalPatientID <-subset(patientData,subset=Sub.type=="basal")
nrow(basalPatientID)


testData <- proteinData[1,]
testData <- proteinData[which(basalPatientID$Patient.ID)]
