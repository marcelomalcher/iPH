package iph.session.server;


public class TestService {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		//
		CollaborativeSessionServer server = new CollaborativeSessionServer();
		
		String region = "Sala1";
		
		server.getCollaborativeSessionsRegion(region);
		
		//
		server.addCollaborativeSession(region, "192.168.0.192", 10, "", "Owner1");		
		server.addCollaborativeSession(region, "192.168.0.192", 12, "", "Owner1");		
		server.addCollaborativeSession(region, "192.168.0.192", 11, "", "Owner2");
		
		CollaborativeSession[] sessions = server.getCollaborativeSessionsRegion(region);
		
		System.out.println("Sessions: " + sessions.length);
		
		

	}

}
