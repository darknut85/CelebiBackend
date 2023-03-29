import random

print("Guess the number")
n = random.randrange(1,100)
guess = 0
while guess == 0:
    i = input("Enter a number")
    if i.isdigit() == True:
        guess = int(i)
        print("Your number is:",guess)
        while n!= guess:
            if guess < n:
                print("Guess is too low")
                j = input("Please enter a number again")
                while j.isdigit() != True:
                    j = input("Not a valid number. Enter a number again")
                guess = int(j)
            elif guess > n:
                print("Guess is too high")
                j = input("Please enter a number again")
                while j.isdigit() != True:
                    j = input("Not a valid number. Enter a number again")
                guess = int(j)
            else:
                break
            
        print("Correct")
    else:
        print("Your number is:",i,"And therefore not valid")
        guess = 0

