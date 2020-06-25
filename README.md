# ProjetMOM_A4

To setup the JEE environment

1) in cmd run ```asadmin --user admin create-domain --portbase 13000 --savemasterpassword=true checker```

	admin password achecker

2) in cmd run ```asadmin --user admin create-domain --portbase 14000 --savemasterpassword=true receiver```

	admin password areceiver

3) add them both in netbeans

4) Go to Projects -> checkerBusiness-ejb -> Properties -> Run 
	
	select "checker" as the server

5) Go to Projects -> checkerFacade-ejb -> Properties -> Run 
	
	select "receiver" as the server

6) Go back to Services and launch both domains

7) Right click on the domain receiver -> View Domain Admin Console

8) Go to Resources -> JMS Resources -> Destination Resources

	create a new queue :
		JNID Name : jms/messageQueue
		Physical Destination Name : physMessageQueue
		Resource Type javax.jms.Queue

	Don't forget to save this time and for the next steps

9) You can now close this admin console and go back to netbeans

10) Right click on the domain checker -> View Domain Admin Console

11) Go to Configuration -> sever-config -> Java Message Service 
	
	set the JMS Service Type to REMOTE

12) Go to Configurations -> server-config -> System Properties
	
	Change the port value to 14076

13) Go back to Configuration -> sever-config -> Java Message Service
	
	Try to ping the service, it should succeed

14) Close the admin console, restart the checker domain from netbeans and then re-open the admin console

15) Go to Resources -> JMS Resources -> Destination Resources 
	
	create a new queue :
		JNID Name : jms/messageQueue
		Physical Destination Name : physMessageQueue
		Resource Type javax.jms.Queue

16) The configuration should be over !

17) Run both checkerFacade-ejb and checkerBusiness-ejb

18) In checkerFacade-ejb go to Web Services -> CheckerService
	Right click it and select Test Web Service

19) Test the webservice with <?xml version="1.0" encoding="UTF-8" standalone="yes"?><msg><opStatus>false</opStatus><info>some info</info></msg>