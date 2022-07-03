# Rise Technology Örnek Proje
#
#
Bu program Rise Tehnology için hazırlanmıştır. 
Hazırlayan: Serhan Altug ([saltug@yahoo.com]) 
Tarih: 2 Temmuz 2022 

## Uygulama Hakkında

.NET Core ile basit bir rehber oluşturulması istendi.
Uygulama WebApi olarak Yeni kişi ekleme, güncelleme, silme gibi basit CRUD işlemleri içermektedir.
Kişilere iletişim bilgileri ekleme, güncelleme ve silme yapılabiliyor.
Ayrıca iletişim bilgilerinde yer alan konuma göre kişi sayısı ve kayıtlı telefon sayısı rapor olarak alınabiliyor. Ayrıntılar için Assessment.pdf dosyasına bakınız.

Swagger yada Postman ile test edilebilir.

## Uygulamanın Çalıştırımlası

Uygulama .net core 6.0 ile geliştirildi. PostgreSql 14 kullanıldı.
Uygulamayı çalıştırmadan önce komut satırından aşağıdaki komutu çalıştırarak bilgisayarınızda veritabanını oluşturun.

```sh
dotnet ef database update -c PostgreSqlEfDbContext -p RT.Contacts.DataAccess
```

## Kafka kurulumu için
Bilgisayarınızda docker kurulu olmalı.

Proje klasöründe bulunan docker-compose.yml dosyasında Kafla için gerekli container imajları yer almaktadır.
İlgili klasörde Power Shell yada Console ekranı açarak aşağıdaki komutu çalıştırın.
#### Bu kurulum biraz zaman alacaktır.
```sh
docker-compose -f docker-compose.yml up -d
```

Docker Kafka Shell'e bağlanmak için:
```sh
docker exec -it kafka /bin/sh
```

Yeni bir topic oluşturmak için aşağıdaki komutu çalıştırın.
```sh
kafka-topics.sh --create --zookeeper zookeeper:2181 --replication-factor 1 --partitions 1 --topic commands
```

   [saltug@yahoo.com]: <mailto://saltug@yahoo.com>
