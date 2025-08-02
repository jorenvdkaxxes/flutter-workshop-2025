import 'package:provider/provider.dart';
import 'package:provider/single_child_widget.dart';
import 'package:simply_lifestyle_app/data/repositories/auth/auth_repository.dart';
import 'package:simply_lifestyle_app/data/repositories/auth/auth_repository_dev.dart';
import 'package:simply_lifestyle_app/data/repositories/auth/auth_repository_remote.dart';
import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository.dart';
import 'package:simply_lifestyle_app/data/repositories/orders/orders_repository_remote.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository_local.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository_remote.dart';
import 'package:simply_lifestyle_app/data/services/api/auth_api_client.dart';
import 'package:simply_lifestyle_app/data/services/local/local_data_service.dart';
import 'package:simply_lifestyle_app/ui/auth/logout/view_models/logout_viewmodel.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/orders_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/products_view_model.dart';
import 'package:simply_lifestyle_app/data/services/shared_preferences_service.dart';

import '../data/services/api/api_client.dart';

/// Configure dependencies for remote data.
/// This dependency list uses repositories that connect to a remote server.
List<SingleChildWidget> get providersRemote {
  return [
    Provider(
      create: (context) => AuthApiClient(),
    ),
    Provider(
      create: (context) => ApiClient(),
    ),
    Provider(
      create: (context) => SharedPreferencesService(),
    ),
    ChangeNotifierProvider(
      create: (context) => AuthRepositoryRemote(
        authApiClient: context.read(),
        apiClient: context.read(),
        sharedPreferencesService: context.read(),
      ) as AuthRepository,
    ),
    Provider(
      create: (context) => ProductsRepositoryRemote(
        apiClient: context.read(),
      ) as ProductsRepository,
    ),
    Provider(
      create: (context) => OrdersRepositoryRemote(
        apiClient: context.read(),
      ) as OrdersRepository,
    ),
    ChangeNotifierProvider(
        create: (context) =>
            ProductsViewModel(productsRepository: context.read())),
    ChangeNotifierProvider(
        create: (context) => OrdersViewModel(ordersRepository: context.read())),
    Provider(
      create: (context) => LogoutViewModel(authRepository: context.read()),
    )
  ];
}

/// Configure dependencies for local data.
/// This dependency list uses repositories that provide local data.
/// The user is always logged in.
List<SingleChildWidget> get providersLocal {
  return [
    ChangeNotifierProvider.value(
      value: AuthRepositoryDev() as AuthRepository,
    ),
    Provider.value(
      value: LocalDataService(),
    ),
    Provider(
      create: (context) => ProductsRepositoryLocal(
        localDataService: context.read(),
      ) as ProductsRepository,
    ),
  ];
}
