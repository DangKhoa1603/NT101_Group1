import random

# Miller-Rabin test
def is_prime(n, k=5):
    if n < 2:
        return False
    for p in [2, 3, 5, 7, 11]:
        if n % p == 0:
            return n == p

    r, d = 0, n - 1
    while d % 2 == 0:
        d //= 2
        r += 1

    for _ in range(k):
        a = random.randint(2, n - 2)
        x = pow(a, d, n)
        if x == 1 or x == n - 1:
            continue
        for _ in range(r - 1):
            x = pow(x, 2, n)
            if x == n - 1:
                break
        else:
            return False
    return True

# Sinh số nguyên tố n-bit
def generate_prime(bits):
    while True:
        num = random.getrandbits(bits)
        if is_prime(num):
            return num

# GCD - Euclid
def gcd(a, b):
    while b:
        a, b = b, a % b
    return a

# Modular exponentiation
def mod_exp(a, x, p):
    result = 1
    a = a % p
    while x > 0:
        if x % 2 == 1:
            result = (result * a) % p
        a = (a * a) % p
        x //= 2
    return result

# Demo
print("Prime 8-bit:", generate_prime(8))
print("Prime 16-bit:", generate_prime(16))
print("Prime 64-bit:", generate_prime(64))

print("GCD(123456, 7890):", gcd(123456, 7890))

print("7^40 mod 19 =", mod_exp(7, 40, 19))
