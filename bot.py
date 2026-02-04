import logging
from telegram import Update, InlineKeyboardButton, InlineKeyboardMarkup, WebAppInfo
from telegram.ext import Application, CommandHandler, ContextTypes

logging.basicConfig(
    format='%(asctime)s - %(name)s - %(levelname)s - %(message)s',
    level=logging.INFO
)
logger = logging.getLogger(__name__)

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    await update.message.reply_text(
        f"Привет, {user.first_name}!\n\n"
        "Используйте /calc, чтобы открыть калькулятор."
    )

async def calc(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await update.message.reply_text(
        "Нажмите на кнопку, чтобы открыть калькулятор:",
        reply_markup=InlineKeyboardMarkup([
            [InlineKeyboardButton(
                text="Калькулятор 🧮",
                web_app=WebAppInfo(url="https://ВАШ-ДОМЕН.ru/")
            )]
        ])
    )

def main():

    TOKEN = "8522776122:AAFjny0dhEMHTosQIGhdhndfhAnDa9XJPd8"


    application = Application.builder().token(TOKEN).build()


    application.add_handler(CommandHandler("start", start))
    application.add_handler(CommandHandler("calc", calc))


    application.run_polling()

if __name__ == '__main__':

    main()
    