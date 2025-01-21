import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/main.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order_screen.dart';

import 'routes.dart';

GoRouter router() => GoRouter(
      initialLocation: Routes.home,
      debugLogDiagnostics: true,
      routes: [
        GoRoute(
          path: Routes.home,
          builder: (context, state) {
            return MyHomePage();
          },
          routes: [
            GoRoute(
              path: Routes.newOrder,
              builder: (context, state) {
                final viewModel =
                    NewOrderViewModel(productsRepository: context.read());
                return NewOrderScreen(viewModel: viewModel);
              },
            )
          ],
        ),
      ],
    );
