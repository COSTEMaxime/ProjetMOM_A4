
package org.tempuri;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import org.datacontract.schemas._2004._07.contractwcf.Message;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AccessServiceResult" type="{http://schemas.datacontract.org/2004/07/ContractWCF}Message" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "accessServiceResult"
})
@XmlRootElement(name = "AccessServiceResponse")
public class AccessServiceResponse {

    @XmlElement(name = "AccessServiceResult")
    protected Message accessServiceResult;

    /**
     * Gets the value of the accessServiceResult property.
     * 
     * @return
     *     possible object is
     *     {@link Message }
     *     
     */
    public Message getAccessServiceResult() {
        return accessServiceResult;
    }

    /**
     * Sets the value of the accessServiceResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link Message }
     *     
     */
    public void setAccessServiceResult(Message value) {
        this.accessServiceResult = value;
    }

}
