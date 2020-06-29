
package org.datacontract.schemas._2004._07.contractwcf;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;
import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfanyType;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the org.datacontract.schemas._2004._07.contractwcf package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _Message_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "Message");
    private final static QName _MessageInfo_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "info");
    private final static QName _MessageOperationName_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "operationName");
    private final static QName _MessageData_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "data");
    private final static QName _MessageAppToken_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "appToken");
    private final static QName _MessageUserToken_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "userToken");
    private final static QName _MessageOperationVersion_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "operationVersion");
    private final static QName _MessageAppVersion_QNAME = new QName("http://schemas.datacontract.org/2004/07/ContractWCF", "appVersion");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: org.datacontract.schemas._2004._07.contractwcf
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link Message }
     * 
     */
    public Message createMessage() {
        return new Message();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Message }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "Message")
    public JAXBElement<Message> createMessage(Message value) {
        return new JAXBElement<Message>(_Message_QNAME, Message.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "info", scope = Message.class)
    public JAXBElement<String> createMessageInfo(String value) {
        return new JAXBElement<String>(_MessageInfo_QNAME, String.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "operationName", scope = Message.class)
    public JAXBElement<String> createMessageOperationName(String value) {
        return new JAXBElement<String>(_MessageOperationName_QNAME, String.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfanyType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "data", scope = Message.class)
    public JAXBElement<ArrayOfanyType> createMessageData(ArrayOfanyType value) {
        return new JAXBElement<ArrayOfanyType>(_MessageData_QNAME, ArrayOfanyType.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "appToken", scope = Message.class)
    public JAXBElement<String> createMessageAppToken(String value) {
        return new JAXBElement<String>(_MessageAppToken_QNAME, String.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "userToken", scope = Message.class)
    public JAXBElement<String> createMessageUserToken(String value) {
        return new JAXBElement<String>(_MessageUserToken_QNAME, String.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "operationVersion", scope = Message.class)
    public JAXBElement<String> createMessageOperationVersion(String value) {
        return new JAXBElement<String>(_MessageOperationVersion_QNAME, String.class, Message.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/ContractWCF", name = "appVersion", scope = Message.class)
    public JAXBElement<String> createMessageAppVersion(String value) {
        return new JAXBElement<String>(_MessageAppVersion_QNAME, String.class, Message.class, value);
    }

}
