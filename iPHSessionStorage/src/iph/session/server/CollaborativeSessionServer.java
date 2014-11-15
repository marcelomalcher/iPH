/**
 * Autor: Marcelo Malcher
 * 
 * MocaWS
 * - Representa o Web Service propriamente dito. 
 * Faz toda a interface para o usu�rio e a partir desta classe � gerado o WSDL.
 *  
 */
package iph.session.server;

import java.util.HashMap;
import java.util.TreeSet;

import javax.jws.WebMethod;
import javax.jws.WebService;


/**
 * Web Service 
 */
@WebService(name="iPHSessionService", serviceName="CollaborativeSessionService")
public class CollaborativeSessionServer {	
	
	/**
	 * Mapa de salas e sess�es colaborativas
	 */
	private HashMap<String, TreeSet<CollaborativeSession>> collaborativeSessionMap = new HashMap<String, TreeSet<CollaborativeSession>>();
	
	/**
	 * M�todo Construtor
	 *
	 */	
	public CollaborativeSessionServer(){
		System.out.println("> CollaborativeSessionServer started!...");
	}	
	
	/**
	 * isConnected
	 * Testa conex�o com o web service
	 * @return boolean
	 */
	@WebMethod(operationName="isConnected", action="urn:isConnected")
	public boolean isConnected() {		
        return true;                      
    }

	/**
	 * Adiciona sess�o � uma regi�o
	 * @param region
	 * @param ip
	 * @param port
	 * @param password
	 * @return se a sess�o foi inserida com sucesso
	 */
	@WebMethod(operationName="addCollaborativeSession", action="urn:addCollaborativeSession")
	public boolean addCollaborativeSession(String region, String ip, int port, String password, String owner) {
		//Cria nova sess�o		
		CollaborativeSession session = new CollaborativeSession(ip, port, password, owner);
		//Procura por sess�es j� inseridas
		TreeSet<CollaborativeSession> sessionSet;
		if (!this.collaborativeSessionMap.containsKey(region)){
			sessionSet = new TreeSet<CollaborativeSession>();
			this.collaborativeSessionMap.put(region, sessionSet);
		}
		sessionSet = this.collaborativeSessionMap.get(region);		
        return sessionSet.add(session);                      
    }
		
	/**
	 * Remove uma sess�o de uma regi�o
	 * @param region
	 * @param ip
	 * @param port
	 * @return se a sess�o foi removida com sucesso
	 */
	@WebMethod(operationName="removeCollaborativeSession", action="urn:removeCollaborativeSession")
	public boolean removeCollaborativeSession(String region, String ip, int port) {
		//Procura por sess�es j� inseridas
		TreeSet<CollaborativeSession> sessionSet = this.collaborativeSessionMap.get(region);
		if (sessionSet == null){
			return false ;
		}		
        return sessionSet.remove(new CollaborativeSession(ip, port));
    }
	
	/**
	 * Limpa as sess�es de uma regi�o
	 * @param region
	 */
	@WebMethod(operationName="clearRegion", action="urn:clearRegion")
	public void clearRegion(String region) {		
		this.collaborativeSessionMap.remove(region);
    }
	
	/**
	 * Limpa todas sess�es
	 * @param region
	 */
	@WebMethod(operationName="clearAll", action="urn:clearAll")
	public void clearAll() {			
		this.collaborativeSessionMap.clear();
    }	
	
	/**
	 * Recupera a lista de sess�es de uma regi�o
	 * @param region
	 * @return lista de sess�es colaborativas
	 */
	@WebMethod(operationName="getCollaborativeSessionsRegion", action="urn:getCollaborativeSessionsRegion")
	public CollaborativeSession[] getCollaborativeSessionsRegion(String region) {
		TreeSet<CollaborativeSession> sessions = this.collaborativeSessionMap.get(region);
		if (sessions != null) {
			return sessions.toArray(new CollaborativeSession[sessions.size()]);
		}
		return new CollaborativeSession[0]; 			
    }
}