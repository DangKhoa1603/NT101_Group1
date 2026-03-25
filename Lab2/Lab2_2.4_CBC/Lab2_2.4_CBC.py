from Crypto.Cipher import AES
from Crypto.Util.Padding import pad

# 1. Khởi tạo dữ liệu 1000 bytes
plaintext = b'A' * 1000 
key = b'1234567812345678' # Key 16 bytes cho AES-128
iv = b'abcdefghijklmnop'  # IV 16 bytes

# 2. Chọn Mode để thử nghiệm ( ECB, CBC, CTR...)
mode = AES.MODE_CBC
cipher = AES.new(key, mode, iv)

# 3. Mã hóa
padded_data = pad(plaintext, 16)
ciphertext = bytearray(cipher.encrypt(padded_data))

# 4. Gây lỗi tại byte thứ 26 (nằm trong khối thứ 2)
ciphertext[26] ^= 0x01 

# 5. Giải mã và kiểm tra
cipher_dec = AES.new(key, mode,iv )
decrypted_data = cipher_dec.decrypt(bytes(ciphertext))

# 6. Đếm xem có bao nhiêu khối bị sai so với bản gốc
error_count = 0
for i in range(0, len(padded_data), 16):
    if padded_data[i:i+16] != decrypted_data[i:i+16]:
        error_count += 1
        print(f"Khôi {i//16 + 1}: HỎNG")
    else:
        if i//16 < 5: # Chỉ in vài khối đầu cho gọn màn hình
            print(f"Khối {i//16 + 1}: OK")

print(f"\n=> TỔNG SỐ KHỐI BỊ HỎNG: {error_count}")
