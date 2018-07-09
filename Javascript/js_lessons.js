/*
var firstName = 'John';
console.log(firstName);

var lastName = 'Doe';
var age = 25;

var fullAge = true;
console.log(fullAge);

var job;
console.log(job);

job = 'teacher';
console.log(job);
*/

/*
// Variable Mutation & Type Coercion

var firstName = 'John';
var age = 25;

// Type Coercion
// JS converts data types to join the strings
console.log(firstName + ' ' + age);

// declare multiple variables inline
var job, isMarried;
job = 'teacher';
isMarried = false;

console.log(firstName + ' is a ' + job + ' of ' + age + ' years old. ' + ' Married? ' + isMarried);

// Variable Mutation
// data type is converted on the fly dynamically
age = 'twenty eight';
job = 'driver';

//alert: display a popup window
alert(firstName + ' is a ' + job + ' of ' + age + ' years old. ' + ' Married? ' + isMarried);

// prompt: user input from a popup window
var lastName = prompt('What is his last name?');
console.log(firstName + ' ' + lastName);
*/

/*
// basic operators
var ageJohn = 28;
var ageMark = 35;
var yearJohn = 2018 - ageJohn;
var yearMark = 2018 - ageMark;
console.log(yearJohn);

var johnOlder = ageJohn > ageMark;
console.log(johnOlder);

//typeof operator: returns the data type
console.log(typeof johnOlder);

//Multiple assignments
var x, y;
// precedence of = is from right to left -> x not undefined
x = y = (3+5)*4-6;
console.log(x,y);

x *=2;
console.log(x);

x++;
console.log(x);
*/

/*
// ex1
// BMI = mass[kg] / height[m]*2

var johnWeight, markWeight, johnHeight, markHeight, johnBmi, markBmi, isHigher; 

johnWeight = 75; 
markWeight = 83;
johnHeight = 1.82;
markHeight = 1.75;

function bmi(weight, height)
{
    return weight/(height*height);
};

johnBmi = bmi(johnWeight, johnHeight);
markBmi = bmi(markWeight, markHeight);
isHigher = johnBmi > markBmi;

console.log("John: " + johnBmi);
console.log("Mark: " + markBmi);
console.log("John\'s BMI higher than Mark\'s ? " + isHigher);
*/

/*
var firstName = 'John';
var civilStatus = 'single';

// ===: returns boolean -> strict equality
if (civilStatus === 'married'){
    console.log(firstName + ' is married.');
} else {
    console.log(firstName + ' is single.');
};
*/

/*
// Ternary Operator and Switch Statements
var firstName = 'John';
var age = 22;

// Ternary Operator: if/else inline
age >= 18 ? console.log(firstName + ' can drink a beer.') : console.log(firstName + ' cannot drink a beer.');

var drink = age >= 18 ? 'beer' : 'juice';
console.log(drink);

// Switch Statement
var job = 'cop';

// Switch with a variable
switch(job) {
    case 'teacher':
        console.log(firstName + ' teaches kids.');
        break;
    case 'driver':
        console.log(firstName + ' drives cars.');
        break;
    default:
        console.log(firstName + ' doesn\'t do anything known.');
}

job = 'driver';
// Switch with a value
switch(true) {
    case job === 'teacher':
        console.log(firstName + ' teaches kids.');
        break;
    case job === 'driver':
        console.log(firstName + ' drives cars.');
        break;
    default:
        console.log(firstName + ' doesn\'t do anything known.');
}
*/

/*
//Truthy and Falsy Values

//Falsy values in an if statement: undefined, null, 0, '', NaN --> beware of 0 value!!
//Truthy values in an if statement: not falsy

var height = 0;

if (height || height === 0){
    console.log('variable defined')
}
else{
        console.log('variable not defined.')
}
*/

/*
// Ex.2
// John: 89, 120, 103
// Mark: 116, 94, 123
// Mary: 97, 134, 105

var jGame1, jGame2, jGame3, mkGame1, mkGame2, mkGame3, myGame1, myGame2, myGame3, avgJohn, avgMark, avgMary;

jGame1 = 90;
jGame2 = 120;
jGame3 = 103;

mkGame1 = 200;
mkGame2 = 120;
mkGame3 = 103;

myGame1 = 100;
myGame2 = 120;
myGame3 = 103;

function average (s1, s2, s3) {
    return (s1 + s2 +s3)/3
}

avgJohn = average(jGame1, jGame2, jGame3);
avgMark = average(mkGame1, mkGame2, mkGame3);
avgMary = average(myGame1, myGame2, myGame3);

switch (true){
    case avgJohn === avgMark && avgMark === avgMary:
        console.log('It\'s a draw!')
        break;
    case (avgJohn > avgMark && (avgMark >= avgMary || avgMark < avgMary)):
        console.log('John wins with ' + avgJohn + ', while Mary has ' + avgMary + ', and Mark has ' + avgMark);
        break;
    case (avgMark > avgJohn && (avgJohn >= avgMary || avgJohn < avgMary)):
        console.log('Mark wins with ' + avgMark + ', while Mary has ' + avgMary + ', and John has ' + avgJohn);
        break;
    case (avgMary > avgJohn && (avgJohn >= avgMark || avgJohn < avgMark)):
        console.log('Mary wins with ' + avgMary + ', while Mark has ' + avgMark + ', and John has ' + avgJohn);
        break;
}
*/

