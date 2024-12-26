import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:simply_lifestyle_app/models/product.dart';

class ProductsPage extends StatefulWidget {
  const ProductsPage({super.key});

  @override
  State<ProductsPage> createState() => _ProductsPageState();
}

class _ProductsPageState extends State<ProductsPage> {
  late Future<List<Product>> futureProducts;
  final List<String> items = List<String>.generate(5, (i) => 'Product $i');

  @override
  void initState() {
    super.initState();
    futureProducts = fetchProducts();
  }

  Future<List<Product>> fetchProducts() async {
    final response =
        await http.get(Uri.parse('https://localhost:7190/api/Products/Get'));

    if (response.statusCode == 200) {
      // If the server did return a 200 OK response,
      // then parse the JSON.
      Iterable l = json.decode(response.body);
      return List<Product>.from(l.map((model) => Product.fromJson(model)));
    } else {
      // If the server did not return a 200 OK response,
      // then throw an exception.
      throw Exception('Failed to load album');
    }
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Product>>(
        future: futureProducts,
        builder: (context, products) {
          if (!products.hasData) {
            return Container();
          }
          return ListView.builder(
            itemCount: products.data!.length,
            prototypeItem: ListTile(
              title: Text(products.data!.first.name),
            ),
            itemBuilder: (context, index) {
              return ListTile(
                title: Text(products.data![index].name),
                subtitle: Text(products.data![index].description),
              );
            },
          );
        });
  }
}
