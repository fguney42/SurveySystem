# :bar_chart: **Anket Sistemi**

**Amaç:**  
Bu sistem, kullanıcıların anketler oluşturabileceği, mevcut anketlere katılabileceği ve sonuçları görüntüleyebileceği dinamik bir platform sunmayı amaçlar.

---

## :star2: **Özellikler**

- **Kimlik Doğrulama:**  
  Kullanıcıların sisteme güvenli bir şekilde giriş yapabilmesi için kimlik doğrulama gereklidir.
  
- **Anket Yönetimi:**  
  Kullanıcılar, yeni anketler oluşturabilir, mevcut anketlere katılabilir ve sonuçları görüntüleyebilir.

- **Veri Depolama:**  
  Kullanıcılar anketlere katıldıklarında, verdikleri cevaplar güvenli bir şekilde depolanır.

- **Dinamik Sonuç Görüntüleme:**  
  Anket sonuçları, kullanıcıların her an görebileceği şekilde dinamik olarak güncellenir.

---

## :bulb: **Temel İşlevler**

1. **Anket Oluşturma:**  
   - Kullanıcılar, anket soruları ve seçenekleri ile yeni anketler oluşturabilir.
   
2. **Ankete Katılma:**  
   - Kullanıcılar mevcut anketlere katılarak, belirledikleri seçeneklere cevap verebilir.

3. **Sonuçları Görüntüleme:**  
   - Kullanıcılar, katıldıkları anketlerin sonuçlarını anlık olarak görebilir. Bu veriler dinamik bir yapıda sunulur.

4. **Sisteme Giriş/Çıkış:**  
   - **JWT Token** ile güvenli giriş ve çıkış işlemleri sağlanır.

5. **Cacheleme:**  
   - Performans artırıcı **cacheleme mekanizması** ile site daha hızlı hale getirilir, kullanıcı deneyimi iyileştirilir.

6. **Loglama:**  
   - Sistemde yapılan tüm işlemler **loglanır** ve kayıt tutulur. Böylece, kullanıcı aktiviteleri takip edilebilir.

7. **Rol Sistemi:**  
   - **Rol bazlı güvenlik** ile kullanıcılar farklı yetkilerle sisteme erişebilir. JWT Token kullanılarak kullanıcıların sistemdeki rolleri doğrulanır.

---

## :pencil2: **Teknolojiler:**
- **Backend:** Node.js, Express.js
- **Frontend:** React, HTML5, CSS3
- **Veritabanı:** MongoDB
- **Authentication:** JWT Token

---

## :rocket: **Kurulum ve Kullanım**

1. Bu projeyi yerel makinenize klonlayın:

   ```bash
   git clone https://github.com/kullanici/anket-sistemi.git
