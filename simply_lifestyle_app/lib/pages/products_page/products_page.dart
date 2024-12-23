import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/controller.dart';

class ProductsPage extends StatefulWidget {
  const ProductsPage({super.key, required this.controller});

  final Controller controller;

  @override
  State<ProductsPage> createState() => _ProductsPageState();
}

class _ProductsPageState extends State<ProductsPage> {
  final List<String> items = List<String>.generate(5, (i) => 'Products $i');

  void addItem() {
    setState(() {
      items.add('New item');
    });
  }

  @override
  void initState() {
    super.initState();
    widget.controller.addItem = addItem;
  }

  @override
  void dispose() {
    super.dispose();
    widget.controller.addItem = null;
  }

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: items.length,
      prototypeItem: ListTile(
        title: Text(items.first),
      ),
      itemBuilder: (context, index) {
        return ListTile(
          title: Text(items[index]),
        );
      },
    );
  }
}
