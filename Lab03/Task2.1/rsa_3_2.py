
th2_hex = "C87F570FC4F699CEC24020C6F54221ABAB2CE0C3"
raw_bytes = bytes.fromhex(th2_hex)

keys = [
    {"id": 2, "n": 13588476140342208394395166469647627226674348541791, "d": 7993221259024828467291262184080358019185876599873},
    {"id": 3, "n": 101776877529005912638346811918779931246783058062684819617574643018368103302097, "d": 24212225287904763939160097464943268930139828978795606022583874367720623008491}
]

for key in keys:
    for byte_order in ['big', 'little']:
        C = int.from_bytes(raw_bytes, byteorder=byte_order)

        M = pow(C, key['d'], key['n'])
        
        try:
            byte_len = (M.bit_length() + 7) // 8 or 1
            text = M.to_bytes(byte_len, byteorder=byte_order).decode('utf-8')

            if any(c.isprintable() or c in '\n\r\t' for c in text):
                print(f"THÀNH CÔNG! khớp với Khóa số {key['id']} (Chuẩn {byte_order}-endian):")
                print(f"BẢN RÕ: {text}\n")
        except:
            pass
