class LoginRequest {
  LoginRequest({required this.email, required this.password});

  final String email;
  final String password;

  factory LoginRequest.fromJson(Map<String, dynamic> json) {
    return switch (json) {
      {
        'email': String email,
        'password': String password,
      } =>
        LoginRequest(email: email, password: password),
      _ => throw const FormatException('Failed to load login request.'),
    };
  }

  Map<String, dynamic> toJson() {
    return {'email': email, 'password': password};
  }
}
