import base64

keys = [
    {"id": 1, "n": 187, "d": 23, "k": 1},
    {"id": 2, "n": 13588476140342208394395166469647627226674348541791, "d": 7993221259024828467291262184080358019185876599873, "k": 21},
    {"id": 3, "n": 101776877529005912638346811918779931246783058062684819617574643018368103302097, "d": 24212225287904763939160097464943268930139828978795606022583874367720623008491, "k": 32}
]

ciphers = {
    "TH1": {"data": "raUcesUlOkx/8ZhgodMoo0Uu18sC20yXlQFevSu7W/FDxIy0YRHMyXcHdD9PBvIT2aUft5fCQEGomiVVPv4I", "type": "base64"},
    "TH2": {"data": "C87F570FC4F699CEC24020C6F54221ABAB2CE0C3", "type": "hex"},
    "TH3": {"data": "Z2BUSkJcg0w4XEpgm0JcMExEQmBlVH6dYEpNTHpMHptMQ7NgTHlgQrNMQ2BKTQ==", "type": "base64"},
    "TH4": {"data": "001010000001010011111111101101110010111011001010111011000110011110111111001111110110100011001111001100001001010001010100111101010100110011101110111011110101101100000100", "type": "bin"}
}

for name, cipher in ciphers.items():
    print(f"\nĐang xử lý {name}")

    try:
        if cipher['type'] == 'base64':
            raw_bytes = base64.b64decode(cipher['data'])
        elif cipher['type'] == 'hex':
            raw_bytes = bytes.fromhex(cipher['data'])
        elif cipher['type'] == 'bin':
            raw_bytes = int(cipher['data'], 2).to_bytes(len(cipher['data']) // 8, byteorder='big')
    except Exception as e:
        print(f"  => [Lỗi chuyển đổi dữ liệu]: {e}")
        continue

    found = False
    for key in keys:
        k = key['k'] 

        if len(raw_bytes) % k != 0:
            continue

        for byte_order in ['little', 'big']:
            plaintext = ""
            is_valid = True
            
            for i in range(0, len(raw_bytes), k):
                block = raw_bytes[i:i+k]
                C = int.from_bytes(block, byteorder=byte_order)
                
                M = pow(C, key['d'], key['n']) 
                
                try:
                    byte_len = (M.bit_length() + 7) // 8 or 1
                    decoded_bytes = M.to_bytes(byte_len, byteorder=byte_order)
                    text = decoded_bytes.decode('utf-8')

                    ##if any(ord(c) < 32 and c not in '\n\r\t' for c in text):
                    ##    is_valid = False
                    ##    break
                    plaintext += text
                except:
                    is_valid = False
                    break

            if is_valid and len(plaintext) > 0:
                print(f"THÀNH CÔNG! Khớp với Khóa số {key['id']} (Chuẩn {byte_order}-endian)")
                print(f"BẢN RÕ: {plaintext}")
                found = True
                break 
        
        if found:
            break 
            
    if not found:
        print("Không giải mã được bằng 3 khóa đã cho.")
