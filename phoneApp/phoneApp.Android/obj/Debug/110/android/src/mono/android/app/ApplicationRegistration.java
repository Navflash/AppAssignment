package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("phoneApp.Droid.MainApplication, phoneApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64a0eae67e1eec71ea.MainApplication.class, crc64a0eae67e1eec71ea.MainApplication.__md_methods);
		
	}
}
