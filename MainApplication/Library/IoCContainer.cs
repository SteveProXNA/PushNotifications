using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

namespace MainApplication.Library
{
	/// <summary>
	/// IoCContainer will resolve/release all applicable object references.
	/// </summary>
	public static class IoCContainer
	{
		private static IKernel KERNEL;

		private static IDictionary<Type, Type> DATA;

		public static void Initialize<T, TImplementation>() where TImplementation : T
		{
			if (null == DATA)
			{
				DATA = new Dictionary<Type, Type>();
			}

			Type t1 = typeof(T);
			Type t2 = typeof(TImplementation);

			if (!DATA.ContainsKey(t1))
			{
				DATA.Add(t1, t2);
			}
			else
			{
				DATA[t1] = t2;
			}
		}

		public static T Resolve<T>()
		{
			if (null == KERNEL)
			{
				INinjectModule module = new EngineModule(DATA);
				INinjectModule[] modules = { module };

				KERNEL = new StandardKernel(modules);
			}

			return KERNEL.Get<T>();
		}

		public static void Release()
		{
			if (null == KERNEL)
			{
				return;
			}

			KERNEL.Dispose();
			KERNEL = null;
		}
	}
}