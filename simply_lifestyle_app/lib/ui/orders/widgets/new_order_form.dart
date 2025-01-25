import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';

class NewOrderForm extends StatefulWidget {
  const NewOrderForm({super.key, required this.products});

  final List<Product> products;

  @override
  State<StatefulWidget> createState() => _NewOrderFormState();
}

class _NewOrderFormState extends State<NewOrderForm> {
  final GlobalKey<FormBuilderState> _formKey = GlobalKey<FormBuilderState>();

  static final _firstDate = DateTime.now();
  static final _lastDate = DateTime(_firstDate.year + 5);

  late final dropDownItems = widget.products
      .map((p) => DropdownMenuItem(
            value: p,
            child: Text(p.name),
          ))
      .toList();

  int orderItemCount = 1;
  final List<Widget> orderItems = [];

  void addOrderItem() {
    var orderItem = Row(
      crossAxisAlignment: CrossAxisAlignment.center,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Padding(
            padding: EdgeInsets.only(right: 4),
            child: Text('Item $orderItemCount')),
        Expanded(
            child: Padding(
          padding: EdgeInsets.only(right: 4),
          child: FormBuilderDropdown(
            name: 'orderItem$orderItemCount',
            items: dropDownItems,
            validator: FormBuilderValidators.compose([
              FormBuilderValidators.required(errorText: 'Choose a product')
            ]),
          ),
        )),
        Expanded(
          child: FormBuilderTextField(
              name: 'orderItemQuantity$orderItemCount',
               decoration: const InputDecoration(
                    labelText: 'Quantity *',
                  ),
              validator: FormBuilderValidators.compose([
                FormBuilderValidators.required(),
                FormBuilderValidators.numeric(),
              ])),
        )
      ],
    );
    setState(() {
      orderItems.add(orderItem);
      orderItemCount++;
    });
  }

  @override
  Widget build(BuildContext context) {
    // Build a Form widget using the _formKey created above.
    return Padding(
      padding: EdgeInsets.all(16),
      child: FormBuilder(
          key: _formKey,
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.only(bottom: 8),
                child: FormBuilderTextField(
                  name: 'customerName',
                  decoration: const InputDecoration(
                    icon: Icon(Icons.person),
                    hintText: 'Customer name',
                    labelText: 'Name *',
                  ),
                  // The validator receives the text that the user has entered.
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: 'Please enter customer name')
                  ]),
                ),
              ),
              Padding(
                  padding: EdgeInsets.only(bottom: 8),
                  child: FormBuilderDateTimePicker(
                    name: 'deliveryDate',
                    inputType: InputType.date,
                    decoration: InputDecoration(
                        icon: Icon(Icons.calendar_today),
                        labelText: 'Delivery date *'),
                    firstDate: _firstDate,
                    lastDate: _lastDate,
                    validator: FormBuilderValidators.compose([
                      FormBuilderValidators.required(
                          errorText: 'Please enter delivery date')
                    ]),
                  )),
              ...orderItems,
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 16),
                child: ElevatedButton(
                  onPressed: addOrderItem,
                  child: const Text('Add order item'),
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 16),
                child: ElevatedButton(
                  onPressed: () {
                    if (_formKey.currentState!
                        .saveAndValidate(focusOnInvalid: false)) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(content: Text('Processing Data')),
                      );
                    }
                  },
                  child: const Text('Submit'),
                ),
              ),
            ],
          )),
    );
  }
}
