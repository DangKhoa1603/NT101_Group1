from Crypto.Cipher import AES

key = b'1234567890123456'
plaintext = b"UIT_LAB_UIT_LAB_UIT_LAB_UIT_LAB_" # 32 bytes (2 khối)

iv = b'0000000000000000'       # IV 16 bytes dùng cho CFB và OFB
nonce_ctr = b'00000000'        # Nonce 8 bytes dùng cho CTR

# 1. Chế độ CFB 
cipher_cfb = AES.new(key, AES.MODE_CFB, iv=iv)
ct_cfb = cipher_cfb.encrypt(plaintext)
print("=== CHẾ ĐỘ CFB ===")
print(f"Khối 1: {ct_cfb.hex()[:32]}")
print(f"Khối 2: {ct_cfb.hex()[32:]}\n")

# 2. Chế độ OFB
cipher_ofb = AES.new(key, AES.MODE_OFB, iv=iv)
ct_ofb = cipher_ofb.encrypt(plaintext)
print("=== CHẾ ĐỘ OFB ===")
print(f"Khối 1: {ct_ofb.hex()[:32]}")
print(f"Khối 2: {ct_ofb.hex()[32:]}\n")

# 3. Chế độ CTR 
cipher_ctr = AES.new(key, AES.MODE_CTR, nonce=nonce_ctr)
ct_ctr = cipher_ctr.encrypt(plaintext)
print("=== CHẾ ĐỘ CTR ===")
print(f"Khối 1: {ct_ctr.hex()[:32]}")
print(f"Khối 2: {ct_ctr.hex()[32:]}\n")



