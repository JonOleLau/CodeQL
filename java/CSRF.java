import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet(name = "CSRFVulnerableServlet", urlPatterns = {"/vulnerable"})
public class CSRF extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            String message = request.getParameter("message");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>CSRF Vulnerable Servlet</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<form action=\"https://example.com/transfer_money\" method=\"post\">");
            out.println("<input type=\"hidden\" name=\"amount\" value=\"1000\"/>");
            out.println("<input type=\"submit\" value=\"Click here to claim your prize!\"/>");
            out.println("</form>");
            out.println("</body>");
            out.println("</html>");
        }
    }
}
