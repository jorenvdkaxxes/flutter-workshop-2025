﻿namespace SimplyLifestyle.Application;

public interface IQuery<out TResult> : IRequest<TResult>
{
}