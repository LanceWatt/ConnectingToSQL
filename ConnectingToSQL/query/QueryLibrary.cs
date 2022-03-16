using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingToSQL.query
{
    public class QueryLibrary
    {

        public static string retrieveFirstName()
        {
            //retrieve the SQL Server instance version
            string query = @"SELECT p.FirstName, p.LastName
                                     FROM person.person p
                                     WHERE p.FirstName IN ( 'Ken', 'David') AND p.emailpromotion = 0";
            return query;
        }

        public static string usingAliases()
        {
            string query = @"SELECT pp.BusinessEntityId, pp.PhoneNumber
                                FROM Person.PersonPhone AS pp
                                WHERE pp.BusinessEntityId = 3";
            return query;        
        }

        public static string usingWhere()
        {
            string query = @"SELECT TOP (1000)
                                p.FirstName, p.LastName
                                FROM Person.Person AS p
                                WHERE p.ModifiedDate > '2013-12-16 00:00:00.000'                                                               
                                ORDER BY p.LastName  DESC;";                           
            return query;
        }

        public static string usingDistinct()
        {
            string query = @"SELECT 
                                COUNT(DISTINCT p.LastName)
                                
                                FROM
                                    Person.Person AS p;
                                ;";
            return query;
        }

        public static string usingSum()
        {
            string query = @"SELECT 
                                SUM(pod.OrderQty)                               
                                FROM Purchasing.PurchaseOrderDetail AS pod;";
            return query;
        }


        //  JOINS
        public static string InnerJoin()
        {
            string query = @"SELECT
                                e.emp_no,
                                e.first_name,
                                e.last_name,
                                dm.dept_no,
                                e.hire_date
                                    FROM
                                employees e
                                    JOIN
                                dept_manager dm ON e.emp_no = dm.emp_no;";
            return query;
        }
        public static string LeftJoin()
        {
            string query = @"SELECT
                                e.emp_no,
                                e.first_name,
                                e.last_name,
                                dm.dept_no,
                                dm.from_date
                                    FROM
                                employees e
                                    LEFT JOIN
                                dept_manager dm ON e.emp_no = dm.emp_no
                                WHERE
                                    e.last_name = 'Markovitch'
                                ORDER BY dm.dept_no DESC, e.emp_no;";
            return query;
        }
        public static string JoinAndWhereTogether()
        {
            string query = @"SELECT
                                e.emp_no,
                                e.first_name,
                                e.last_name,
                                e.hire_date,
                                t.title
                                    FROM
                                employees e
                                    JOIN
                                titles t ON e.emp_no = t.emp_no
                                WHERE
                                    first_name = 'Margareta'
                                AND 
                                    last_name = 'Markovitch'
                                ORDER BY e.emp_no;";
            return query;
        }

        public static string JoiningMultipleTables()
        {
            string query = @"SELECT
                                e.first_name,
                                e.last_name,
                                e.hire_date,
                                t.title,
                                m.from_date,
                                d.dept_name
                                    FROM
                                employees e
                                    JOIN
                                 dept_manager m ON e.emp_no = m.emp_no
                                    JOIN
                                departments d ON m.dept_no = d.dept_no
                                    JOIN
                                    titles t ON e.emp_no = t.emp_no
                                    WHERE t.title = 'Manager'
                                ORDER BY d.emp_no;";
            return query;
        }
    }
}
