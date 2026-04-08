import base64

def rsa_encrypt_message_to_base64(message, e, n):
    encrypted_bytes = bytearray()

    block_size = (n.bit_length() + 7) // 8

    for char in message:
        m = ord(char)

        c = pow(m, e, n)

        encrypted_char_bytes = c.to_bytes(block_size, byteorder='big')
        encrypted_bytes.extend(encrypted_char_bytes)

    base64_string = base64.b64encode(encrypted_bytes).decode('utf-8')
    return base64_string

def main():
    message = "The University of Information Technology"
    print(f"Bản rõ: {message}\n")

    # TRƯỜNG HỢP 1
    n1 = 187
    e1 = 7
    cipher_base64_1 = rsa_encrypt_message_to_base64(message, e1, n1)
    print("Trường hợp 1:")
    print(cipher_base64_1)
    print("-" * 40)

    # TRƯỜNG HỢP 2
    n2 = 13588476140342208394395166469647627226674348541791
    e2 = 17 
    cipher_base64_2 = rsa_encrypt_message_to_base64(message, e2, n2)
    print("Trường hợp 2:")
    print(cipher_base64_2)
    print("-" * 40)

    # TRƯỜNG HỢP 3
    n3 = 101776877529005912638346811918779931246783058062684819617574643018368103302097
    e3 = 886979
    cipher_base64_3 = rsa_encrypt_message_to_base64(message, e3, n3)
    print("Trường hợp 3:")
    print(cipher_base64_3)

if __name__ == '__main__':
    main()
    
    
    
    
    
