import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';

class OrderItemRow extends StatelessWidget {
  const OrderItemRow(
      {super.key, required this.count, required this.dropDownItems, required this.removeCallBack});

  final int count;
  final List<DropdownMenuItem<Product>> dropDownItems;
  final Function(int) removeCallBack;

  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.center,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Padding(
            padding: EdgeInsets.only(right: 4),
            child: CircleAvatar(
              maxRadius: 12,
              child: Text(
                '$count',
                style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold),
              ),
            )),
        Expanded(
            child: Padding(
          padding: EdgeInsets.only(right: 4),
          child: FormBuilderDropdown(
            name: 'orderItem_$count',
            items: dropDownItems,
            validator: FormBuilderValidators.compose([
              FormBuilderValidators.required(errorText: 'Choose a product')
            ]),
          ),
        )),
        Expanded(
          child: FormBuilderTextField(
              name: 'orderItemQuantity_$count',
              decoration: const InputDecoration(
                labelText: 'Quantity *',
              ),
              validator: FormBuilderValidators.compose([
                FormBuilderValidators.required(),
                FormBuilderValidators.numeric(),
              ])),
        ),
        IconButton(onPressed: () => removeCallBack(count), icon: Icon(Icons.remove))
      ],
    );
  }
}
