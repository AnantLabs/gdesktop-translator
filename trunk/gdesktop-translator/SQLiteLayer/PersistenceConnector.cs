using System;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections;

namespace SQLiteLayer
{
    public struct LeardWordRecord
    {
        public long id;
        public String word;
        public String translation;
        public long learnCount;
        public long learned;
    };
    public class PersistenceConnector
    {
        public static String cacheFullPath;
        public const String cacheFileName = "\\Cache\\cache.ldb";
        
        private SQLiteConnection localCacheConnection;
        private SQLiteCommand getCommand;
        private SQLiteCommand putCommand;
        private SQLiteCommand updateCommand;

        private SQLiteParameter srcParam;
        private SQLiteParameter srcLangParam;
        private SQLiteParameter destLangParam;
        private SQLiteParameter translationParam;


        public PersistenceConnector(String pathToCache)
        {
            cacheFullPath = pathToCache + cacheFileName;
            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
            localCacheConnection = (SQLiteConnection)fact.CreateConnection();
            localCacheConnection.ConnectionString = "Data Source="+cacheFullPath;
            //MessageBox.Show(localCacheConnection.ConnectionString);
            localCacheConnection.Open();

            //get value from cache command
            getCommand = new SQLiteCommand(localCacheConnection);
            getCommand.CommandText = get_query;

            srcParam = new SQLiteParameter();
            srcParam.DbType = System.Data.DbType.String;

            srcLangParam = new SQLiteParameter();
            srcParam.DbType = System.Data.DbType.String;

            destLangParam = new SQLiteParameter();
            srcParam.DbType = System.Data.DbType.String;

            translationParam = new SQLiteParameter();
            translationParam.DbType = System.Data.DbType.String;

            getCommand.Parameters.Add(srcParam);
            getCommand.Parameters.Add(srcLangParam);
            getCommand.Parameters.Add(destLangParam);

            //insert into cache command
            putCommand = new SQLiteCommand(localCacheConnection);
            putCommand.CommandText = put_query;

            putCommand.Parameters.Add(srcParam);
            putCommand.Parameters.Add(srcLangParam);
            putCommand.Parameters.Add(destLangParam);
            putCommand.Parameters.Add(translationParam);

            //Update last used date command
            updateCommand = new SQLiteCommand(localCacheConnection);
            updateCommand.CommandText = update_date_query;

            updateCommand.Parameters.Add(srcParam);
            updateCommand.Parameters.Add(srcLangParam);
            updateCommand.Parameters.Add(destLangParam);
        }

        public string get(String sourceText, String sourceLang, String destinalionLang )
        {
            using (SQLiteTransaction getTransaction = localCacheConnection.BeginTransaction())
            {
                srcParam.Value = sourceText;
                srcLangParam.Value = sourceLang;
                destLangParam.Value = destinalionLang;

                //MessageBox.Show(getCommand.ToString());
                SQLiteDataReader dr = getCommand.ExecuteReader();
                String result;
                if (dr.Read())
                {
                    result = dr.GetString(0);
                    //Refresh last used date
                    //to know most recent user records
                    int r = updateCommand.ExecuteNonQuery();
                }
                else
                    result = sourceText;
                dr.Close();
                //MessageBox.Show("Comm");
                getTransaction.Commit();
                return result;
            }
        }

        public long cacheRecordsCount()
        {
            if (!ifConnectionInnormalState()) return -1;
            SQLiteCommand sizeCommand = new SQLiteCommand(localCacheConnection);
            sizeCommand.CommandText = size_query;

            //MessageBox.Show(getCommand.ToString());
            SQLiteDataReader dr = sizeCommand.ExecuteReader();
            long result;
            if (dr.Read())
                result = dr.GetInt64(0);
            else
                result = -1;
            dr.Close();
            return result;
        }

        public void put(String sourceText, String sourceLang, String destinalionLang, String translation)
        {
            using (SQLiteTransaction putTransaction = localCacheConnection.BeginTransaction())
            {
                srcParam.Value = sourceText;
                srcLangParam.Value = sourceLang;
                destLangParam.Value = destinalionLang;
                translationParam.Value = translation;
                

                //MessageBox.Show(putCommand.ToString());
                putCommand.ExecuteNonQuery();
                putTransaction.Commit();
            }
        }

        public void clear()
        {
            if (!ifConnectionInnormalState()) return;

            using (SQLiteTransaction clearTransaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand clearCommand = new SQLiteCommand(localCacheConnection);
                clearCommand.CommandText = clear_query;

                clearCommand.ExecuteNonQuery();
                clearTransaction.Commit();
            }
        }

        public void deleteoldRecords()
        {
            //Deletes older than 15 days records
            
            if (!ifConnectionInnormalState()) return;

            using (SQLiteTransaction clearTransaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand clearCommand = new SQLiteCommand(localCacheConnection);
                clearCommand.CommandText = rem_old_query;

                clearCommand.ExecuteNonQuery();
                clearTransaction.Commit();
            }
        }

        private bool ifConnectionInnormalState()
        {
            if (localCacheConnection == null) return false;

            if (localCacheConnection.State != System.Data.ConnectionState.Open) return false;

            return true;
        }

        public string getServerVersion()
        {
            return localCacheConnection.ServerVersion;
        }

        public long getCacheSize()
        {
            System.IO.FileInfo fi = new FileInfo(cacheFullPath);
            return fi.Length;
        }

        public String getCacheSizeInKB()
        {
            double size = getCacheSize();
            double sizeInMB = Math.Round((double)size/(1024),2);
            return sizeInMB.ToString() + " KB";
        }

        ~PersistenceConnector()
        {
            if (localCacheConnection != null)
                if (localCacheConnection.State == System.Data.ConnectionState.Open)
                localCacheConnection.Close();
        }

        #region sql_queries
        private static String get_query = "select translation from translationCache " +
                                          " where source=? " +
                                          " and source_lang = ? " +
                                          " and destination_lang = ?";

        private static String put_query = " insert into translationCache (source,source_lang,destination_lang,translation,creation_date,last_used_date) values(?,?,?,?,julianday('now'),julianday('now'))";

        private static String clear_query = " delete from translationCache";

        private static String size_query = "select count(*) from  translationCache";

        private static String update_date_query = " update translationCache " +
                                          " set  last_used_date =  julianday('now')" +
                                          " where source=? " +
                                          " and source_lang = ? " +
                                          " and destination_lang = ?";

        private static String rem_old_query = " delete from translationCache where last_used_date <=julianday(date('now', '-15 days'))";
        #endregion
        public void addTextToLearn(String word, String translation, String category)
        {
            if (!ifConnectionInnormalState()) return;
            String insertQuery = "insert into learnWords(text_to_learn,translation,category,learnCount,learned) values(@word,@translation,@category,0,0)";
            using (SQLiteTransaction addTransaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand clearCommand = new SQLiteCommand(localCacheConnection);
                clearCommand.CommandText = insertQuery;
                clearCommand.Parameters.Add("word", System.Data.DbType.String).Value = word;
                clearCommand.Parameters.Add("translation", System.Data.DbType.String).Value = translation;
                clearCommand.Parameters.Add("category", System.Data.DbType.String).Value = category;
                clearCommand.ExecuteNonQuery();
                addTransaction.Commit();
            }
        }

        public LeardWordRecord getNextRecordForLearning(ArrayList selectedBefore)
        {
            LeardWordRecord record = new LeardWordRecord();
            record.id = -1;
            StringBuilder list = new StringBuilder("-1");
            foreach (object i in selectedBefore)
            {
                list.Append(","+i.ToString());
            }
            if (!ifConnectionInnormalState()) return record;
            String sql = "select id, text_to_learn, translation, learned, learnCount  from learnWords " +
                         "where learned = 0 " +
                         "and id not in ( "+list.ToString()+")" +
                         "order by random() ";
            //MessageBox.Show(sql);

            using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand command = new SQLiteCommand(localCacheConnection);
                command.CommandText = sql;

                SQLiteDataReader dr = command.ExecuteReader();
                
                if (dr.Read())
                {
                    record.id = dr.GetInt64(0);
                    record.word = dr.GetString(1);
                    record.translation = dr.GetString(2);
                    record.learned = dr.GetInt64(3);
                    record.learnCount = dr.GetInt64(4);
                }
                dr.Close();

                transaction.Commit();
            }
            return record; 
        }
        public void increaseLearnCount(long id)
        {
            if (!ifConnectionInnormalState()) return;
            String sql = "update learnWords set learnCount=learnCount +1 where id = " + id;
            using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand command = new SQLiteCommand(localCacheConnection);
                command.CommandText = sql;

                command.ExecuteNonQuery();
                transaction.Commit();
            }
        }
        public void markAsLearned(long id)
        {
            markStatus(id,1);
            
        }
        public void markToLearn(long id)
        {
            markStatus(id,0);
        }

        public void markStatus(long id, int value)
        {
            if (!ifConnectionInnormalState()) return;
            String sql = "update learnWords set learned = " + value + ",learnCount= 0 where id = " + id;
            using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand command = new SQLiteCommand(localCacheConnection);
                command.CommandText = sql;

                command.ExecuteNonQuery();
                transaction.Commit();
            }
        }

        public SQLiteDataReader getLearnRecords()
        {
            if (!ifConnectionInnormalState()) return null;
            String sql = "select id, text_to_learn, translation, learned, learnCount  from learnWords ";
            SQLiteCommand command = new SQLiteCommand(localCacheConnection);
            command.CommandText = sql;
            SQLiteDataReader dr = command.ExecuteReader();
            return dr;
        }

        public void deleteAllLearningRecords()
        {
            if (!ifConnectionInnormalState()) return;
            String sql = "delete from learnWords";
            using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand command = new SQLiteCommand(localCacheConnection);
                command.CommandText = sql;

                command.ExecuteNonQuery();
                transaction.Commit();
            }
        }

        public void deleteRowForLearning(long id)
        {
            if (!ifConnectionInnormalState()) return;
            String sql = "delete from learnWords where id = "+id;
            using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
            {
                SQLiteCommand command = new SQLiteCommand(localCacheConnection);
                command.CommandText = sql;

                command.ExecuteNonQuery();
                transaction.Commit();
            }
        }

        public long getCountWordsForLearning()
        {
            if (!ifConnectionInnormalState()) return -1;
            SQLiteCommand sizeCommand = new SQLiteCommand(localCacheConnection);
            sizeCommand.CommandText = " select count (1) from learnWords where learned = 0 ";

            //MessageBox.Show(getCommand.ToString());
            SQLiteDataReader dr = sizeCommand.ExecuteReader();
            long result;
            if (dr.Read())
                result = dr.GetInt64(0);
            else
                result = -1;
            dr.Close();
            return result;
            
        }

        //public LeardWordRecord getNextRecordForLearning(ArrayList selectedBefore)
        //{
        //    LeardWordRecord record = new LeardWordRecord();
        //    record.id = -1;
        //    StringBuilder list = new StringBuilder("-1");
        //    foreach (object i in selectedBefore)
        //    {
        //        list.Append(","+i.ToString());
        //    }
        //    if (!ifConnectionInnormalState()) return record;
        //    String sql = "select id, text_to_learn, translation, learned, learnCount  from learnWords " +
        //                 "where learned = 0 " +
        //                 "and id not in ( "+list.ToString()+")" +
        //                 "order by random() ";
        //    //MessageBox.Show(sql);

        //    using (SQLiteTransaction transaction = localCacheConnection.BeginTransaction())
        //    {
        //        SQLiteCommand command = new SQLiteCommand(localCacheConnection);
        //        command.CommandText = sql;

        //        SQLiteDataReader dr = command.ExecuteReader();
                
        //        if (dr.Read())
        //        {
        //            record.id = dr.GetInt64(0);
        //            record.word = dr.GetString(1);
        //            record.translation = dr.GetString(2);
        //            record.learned = dr.GetInt64(3);
        //            record.learnCount = dr.GetInt64(4);
        //        }
        //        dr.Close();

        //        transaction.Commit();
        //    }
        //    return record; 
        //}
    }


}
