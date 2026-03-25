from Crypto.Cipher import AES

key = b'1234567890123456'
plaintext = b"UIT_LAB_UIT_LAB_UIT_LAB_UIT_LAB_" # 32 bytes (2 blocks)

# 1. AES-ECB
cipher_ecb = AES.new(key, AES.MODE_ECB)
ct_ecb = cipher_ecb.encrypt(plaintext)

# 2. AES-CBC
iv = b'0000000000000000'                      # Khởi tạo IV 16 bytes cố định
cipher_cbc = AES.new(key, AES.MODE_CBC, iv)   # Khai báo chế độ CBC với Key và IV
ct_cbc = cipher_cbc.encrypt(plaintext)        # Thực hiện mã hóa

print("--- KẾT QUẢ THEO YÊU CẦU ĐỀ BÀI ---")
print(f"ECB: {ct_ecb.hex()}")
print(f"CBC: {ct_cbc.hex()}\n")

print("--- PHÂN TÍCH SO SÁNH ---")
print(f"Plaintext khối 1: {plaintext[:16]}")
print(f"Plaintext khối 2: {plaintext[16:]}\n")

print(f"ECB khối 1: {ct_ecb.hex()[:32]}")
print(f"ECB khối 2: {ct_ecb.hex()[32:]}")

print("\n")

print(f"CBC khối 1: {ct_cbc.hex()[:32]}")
print(f"CBC khối 2: {ct_cbc.hex()[32:]}")




