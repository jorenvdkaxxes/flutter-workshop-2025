// enum ProductType { kaliSeats, fabricSeats }

enum ProductType{
  kaliSeats(name: 'Kali Seats'),
  fabricSeats(name: 'Fabric Seats');

  const ProductType({
    required this.name,
  });

  final String name;
}