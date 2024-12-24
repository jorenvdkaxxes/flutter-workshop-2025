import 'package:flutter/material.dart';
import 'package:simply_lifestyle_app/controller.dart';

class OrdersPage extends StatefulWidget {
  const OrdersPage({super.key, required this.controller});

  final Controller controller;

  @override
  State<OrdersPage> createState() => _OrdersPageState();
}

class _OrdersPageState extends State<OrdersPage> {
  final List<String> items = List<String>.generate(5, (i) => 'Order $i');

  late int index;

  void addItem() {
    setState(() {
      items.add('Order $index');
      index++;
    });
  }

  @override
  void initState() {
    super.initState();
    index = items.length;
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
