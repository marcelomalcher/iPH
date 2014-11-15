package iph.session.server;

/**
 * Classe que salva os dados da sess�o colaborativa
 * @author Marcelo
 *
 */
public class CollaborativeSession implements Comparable<CollaborativeSession> {
	
	/** IP da sess�o */
	private String ip;
	
	/** Porta da sess�o */
	private int port;
	
	/** Senha da sess�o */
	private String password;
	
	/** Owner da Sess�o */
	private String owner;
	
	CollaborativeSession() {};
	
	/**
	 * Construtor padr�o
	 * @param ip
	 * @param port
	 * @param password
	 */
	CollaborativeSession(String ip, int port) {
		this.ip = ip;
		this.port = port ;	
	}
	
	/**
	 * Construtor
	 * @param ip
	 * @param port
	 * @param password
	 */
	CollaborativeSession(String ip, int port, String password, String owner) {
		this.ip = ip;
		this.port = port ;
		this.password = password;
		this.owner = owner;
	}

	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	public int getPort() {
		return port;
	}

	public void setPort(int port) {
		this.port = port;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	
	public String getOwnerSession() {
		return owner;
	}

	public void setOwnerSession(String ownerSession) {
		this.owner = ownerSession;
	}

	@Override
	public boolean equals(Object obj) {
		CollaborativeSession other = (CollaborativeSession)obj;
		return (this.ip.equals(other.getIp()) && (this.port == other.getPort()));
	}

	@Override
	public int compareTo(CollaborativeSession o) {
		if (this.ip.equals(o.getIp()) && (this.port == o.getPort())) {
			return 0;
		}
		return -1;
	}
}
