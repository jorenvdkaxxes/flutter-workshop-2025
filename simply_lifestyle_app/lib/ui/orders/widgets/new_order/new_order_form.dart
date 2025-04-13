import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order/order_item_row.dart';

class NewOrderForm extends StatefulWidget {
  const NewOrderForm(
      {super.key, required this.products, required this.createOrder});

  final List<Product> products;

  final Function(Map<String, dynamic>) createOrder;

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

  void removeOrderItem(int index) {
    setState(() {
      orderItems.removeAt(index - 1);
      orderItemCount--;
        _formKey.currentState!.fields['orderItems']?.didChange(0);
    });
  }

  void addOrderItem() {
    setState(() {
      var orderItem = OrderItemRow(
        count: orderItemCount,
        dropDownItems: dropDownItems,
        removeCallBack: removeOrderItem,
      );
      orderItems.add(orderItem);
      orderItemCount++;
      _formKey.currentState!.fields['orderItems']!.didChange(orderItemCount);
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
                  name: 'customerFirstName',
                  decoration: const InputDecoration(
                    icon: Icon(Icons.person),
                    hintText: 'Customer name',
                    labelText: 'First name *',
                  ),
                  // The validator receives the text that the user has entered.
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: 'Please enter customer first name')
                  ]),
                ),
              ),
              Padding(
                padding: EdgeInsets.only(bottom: 8),
                child: FormBuilderTextField(
                  name: 'customerLastName',
                  decoration: const InputDecoration(
                    icon: Icon(Icons.person),
                    hintText: 'Customer last name',
                    labelText: 'Last name *',
                  ),
                  // The validator receives the text that the user has entered.
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: 'Please enter customer last name')
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
              FormBuilderField(
                  builder: (FormFieldState<dynamic> field) {
                    return InputDecorator(
                      decoration: InputDecoration(
                        labelText: "Order items",
                        contentPadding: EdgeInsets.only(top: 10.0, bottom: 0.0),
                        border: InputBorder.none,
                        errorText: field.errorText,
                      ),
                      child: Column(children: orderItems),
                    );
                  },
                  name: 'orderItems',
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: 'Add order items'),
                  ])),
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
                      widget.createOrder(_formKey.currentState!.value);
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
