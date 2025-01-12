import 'package:flutter/material.dart';

class ProductDetailsRow extends StatelessWidget {
  const ProductDetailsRow(
      {super.key, required this.propertyName, required this.propertyValue});

  final String propertyName;
  final dynamic propertyValue;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
            child: Padding(
          padding: EdgeInsets.only(bottom: 4),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                propertyName,
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
              ),
              Text(
                propertyValue.toString(),
                style: TextStyle(fontSize: 16),
              )
            ],
          ),
        ))
      ],
    );
  }
}
