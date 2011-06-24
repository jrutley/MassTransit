﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit
{
	public interface IBusPublishContext<T> :
		IPublishContext<T>
		where T : class
	{
		/// <summary>
		/// Called for each subscriber of the published message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message"></param>
		/// <param name="endpoint"></param>
		void NotifyForMessageConsumer(T message, IEndpoint endpoint);

		/// <summary>
		/// Called if there are no subscribers for the message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message"></param>
		void NotifyNoSubscribers(T message);

		/// <summary>
		/// Determines if the endpoint was already sent to during this publish
		/// </summary>
		/// <param name="endpoint"></param>
		/// <returns></returns>
		bool WasEndpointAlreadySent(IEndpoint endpoint);

		/// <summary>
		/// Sets the consume context that the publish was created in for tracing
		/// </summary>
		/// <param name="receiveContext"></param>
		void SetReceiveContext(IReceiveContext receiveContext);
	}
}