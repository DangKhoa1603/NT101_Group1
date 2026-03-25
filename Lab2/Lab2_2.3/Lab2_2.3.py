from Crypto.Cipher import DES

def task_23_avalanche_test():
    # 1. Khởi tạo khóa (8 bytes cho DES)
    # Sử dụng MSSV hoặc một chuỗi cố định
    key = b'24520877' # lần lượt thay đổi thành mssv khác: 24521105, 24520877
    cipher = DES.new(key, DES.MODE_ECB)
    
    # 2. Hai bản rõ khác nhau 1 bit ở ký tự cuối
    # 'E' (01000101) và 'A' (01000001) -> Khác nhau ở bit thứ 6
    p1 = b'STAYHOME'
    p2 = b'STAYHOMA'
    
    # 3. Thực hiện mã hóa
    c1 = cipher.encrypt(p1)
    c2 = cipher.encrypt(p2)
    
    # 4. Chuyển đổi bản mã sang dạng chuỗi bit để so sánh
    b1 = bin(int.from_bytes(c1, 'big'))[2:].zfill(64)
    b2 = bin(int.from_bytes(c2, 'big'))[2:].zfill(64)
    
    # 5. Đếm số lượng bit khác nhau (Hamming Distance)
    diff_bits = sum(1 for bit1, bit2 in zip(b1, b2) if bit1 != bit2)
    percentage = (diff_bits / 64) * 100
    
    # In kết quả
    print(f"Bản rõ 1: {p1.decode()} -> Bản mã (hex): {c1.hex()}")
    print(f"Bản rõ 2: {p2.decode()} -> Bản mã (hex): {c2.hex()}")
    print("-" * 30)
    print(f"Số bit khác nhau: {diff_bits}/64")
    print(f"Tỷ lệ thay đổi: {percentage:.2f}%")

if __name__ == "__main__":
    task_23_avalanche_test()

