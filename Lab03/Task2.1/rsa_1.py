def calculate_rsa_keys(p, q, e):
    n = p * q
    phi = (p - 1) * (q - 1)
    d = pow(e, -1, phi) 
    return n, e, d

def main():
    base = int(input("Nhập hệ cơ số của dữ liệu (10 hoặc 16): "))

    p = int(input("Nhập p: "), base)
    q = int(input("Nhập q: "), base)
    e = int(input("Nhập e: "), base)

    n, e, d = calculate_rsa_keys(p, q, e)

    print("\n--- KẾT QUẢ ---")
    print(f"Khóa công khai PU: ({e}, {n})")
    print(f"Khóa riêng PR: ({d}, {n})")

if __name__ == '__main__':
    main()
    
    
    
    
    
    
    
    
